package com.collmotorac;
import java.io.IOException;
import java.util.List;
import com.collmotorac.R;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.app.Service;
import android.content.BroadcastReceiver;
import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;
import android.os.IBinder;
import android.preference.PreferenceManager;
import android.telephony.TelephonyManager;
import android.util.Log;
import android.view.Window;
import android.widget.Toast;

public class Main extends Service {
	static float ERROR_VEHICLE  = .5f;
	static String ADDRESS_NAME = "Desconocida";
	static SharedPreferences prefs;
	static DataBaseHelper myDbHelper;
	static int TIME_UBICATION = 0;
	static boolean ACTIVE = false;
	static Context context;
    private static Main service; 
	static CollMotor collmotor = null;
	private static final String TAG = "CollmotorService";
	public static String ip = "10.116.94.217";
	private static final int COLLMOTOR_ID = 1;
	static SensorManager mSensorManager1;
	static BroadcastReceiver receiver;
	static boolean STARTED_BY_CALL_OUTGOING;
	static boolean STARTED_BY_CALL_INCOMING;
	static String PHONENUMBER_STARTED_BY_CALL;
	TelephonyManager tm;
	Toast t;
	static int count = 0;
	static SensorView mVista; 
	static boolean CONNECT_NETWORK_MOBILE;
	static boolean STARTED = false;
	static boolean STOPED = false;
	static boolean STARTED_GEO = false;
	public static String levelBattery = "";
	public static String temperatureBattery = "";
	

	public static Main getInstance(){
		return service;
	}
	@Override
	public IBinder onBind(Intent intent) {
		return null;
	}

	public static void setCollMotor(CollMotor cm) {
		collmotor = cm;
	}

	@Override
	public void onCreate() {
		Log.d(TAG, "onCreate");		
		prefs = PreferenceManager.getDefaultSharedPreferences(this);
		
		count = 0;
		SensorView.tiempo_inicial = 0;
		SensorView.tiempo_final = 0;
		showMessage("Creating service!!");
		t = new Toast(this);
		mVista = new SensorView(this, t);
		
		settingSensors();
		settingDatabase();
		createNotificationOutgoing();
		service = this;		
	}
	
	public void createNotificationOutgoing(){
		String ns = Context.NOTIFICATION_SERVICE;
		NotificationManager mNotificationManager = (NotificationManager) getSystemService(ns);
		int icon = R.drawable.activity_monitor;
		CharSequence tickerText = "Monitor contextual";
		long when = System.currentTimeMillis();
		Notification notification = new Notification(icon, tickerText, when);
		CharSequence contentTitle = "Activity Recognition Sensor";
		CharSequence contentText = "Recognizing Activities";
		Intent notificationIntent = new Intent(this, CollMotor.class);
		PendingIntent contentIntent = PendingIntent.getActivity(this, 0, notificationIntent, 0);
		notification.setLatestEventInfo(this, contentTitle, contentText, contentIntent);
		notification.flags = Notification.FLAG_ONGOING_EVENT;
		mNotificationManager.notify(COLLMOTOR_ID, notification);
	}
	
	public void showMessage(String text){
		Toast.makeText(this, text, Toast.LENGTH_LONG).show();
	}
	@Override
	public void onDestroy() {
		Toast.makeText(this, "Stopping Activity Recognition Sensor", Toast.LENGTH_LONG).show();
		STOPED = true;
		Log.d(TAG, "onDestroy");
		
		try{
			Main.myDbHelper.close();
		}catch(Exception e){	
		}
	}
	

	@Override
	public void onStart(Intent intent, int startid) {
		Log.d(TAG, "onStart");
		if (!STARTED){
			STARTED = true;
			showMessage( "Starting Activity Recognition Sensor....");				
		}			
	}

	public void settingDatabase(){
		try{
			myDbHelper = new DataBaseHelper(this);
			try {
				myDbHelper.createDataBase();
				try {
					myDbHelper.openDataBase();					
				} catch (Exception sqle) {
				}
			} catch (IOException ioe){
			}				
		}catch(Exception e){	
		}
	}

	
	public void settingSensors() {
		SensorManager mSensorManager = (SensorManager) getSystemService(SENSOR_SERVICE);
		List<Sensor> listSensors = mSensorManager.getSensorList(Sensor.TYPE_ACCELEROMETER);
		Sensor acelerometerSensor = listSensors.get(0);
		mSensorManager.registerListener(mVista, acelerometerSensor, SensorManager.SENSOR_DELAY_UI);
		mSensorManager1 = (SensorManager) getSystemService(SENSOR_SERVICE);
	}
}

class SensorView implements SensorEventListener {
	Main service;
	Window myWindow;
	Toast t;
	static boolean sync_ap_server = false;

	public SensorView() {
		super();
	}

	public SensorView(Main service, Toast t) {
		this.service = service;
		this.t = t;
	}

	private float mAccelerometerValues[] = new float[3];
	private float mMagneticValues[] = new float[3];
	public static long tiempo_inicial;
	public static long tiempo_final;
	
	
	// En este ejemplo no necesitamos enterarnos de las variaciones de precisión del sensor
	@Override
	public void onAccuracyChanged(Sensor sensor, int accuracy) {
		
	}
	
	public static double sumar(double values[]){
		double result = 0;
		//Calcular la sumatoria de cada eje a partir de la matriz generada con las 200 lecturas del acelerómetro
		for (int i = 0; i < values.length; i++)
			result += values[i];
		return result;
	}
	
	public static double calcularPromedio(double values[]){
		double promedio = sumar(values) / values.length;
		return promedio;
	}

	public static double calcularDesviacionEstandar(double promedio, double values[]){
		//Calcular desviación estándar
		double desviacion = 0;
		double diferencia = 0;
		
		for (int i = 0; i < values.length; i++) {
			diferencia = (values[i] - promedio);
			desviacion = desviacion + (diferencia * diferencia);
		}
		desviacion = desviacion / values.length;
		desviacion = Math.sqrt(desviacion);
		return desviacion;
	}
	
	//Algoritmo inicial antes de Sensors 
	public String physicalActivityRecognitionV1(double x[], double y[], double z[]){
		String result = "Nothing...";
		double promedioX = calcularPromedio(x);
		double promedioY = calcularPromedio(y);
		double promedioZ = calcularPromedio(z);
	
		double desviacionX = calcularDesviacionEstandar(promedioX, x);
		double desviacionY = calcularDesviacionEstandar(promedioY, y);
		double desviacionZ = calcularDesviacionEstandar(promedioZ, z);
		
		double acelerationSum = 0;
		double acelerationAvg = 0;
		double SMA = 0;
		
		int rowT = x.length;

		//Calcular la sumatoria de cada eje a partir de la matriz generada con las 200 lecturas del acelerómetro
		for (int i = 0; i < rowT; i++) {
			SMA += (Math.abs(x[i]) + Math.abs(y[i]) + Math.abs(z[i]));
			acelerationSum += (Math.sqrt((x[i] * x[i]) + (y[i] * y[i]) + (z[i] * z[i]))); 
		}
		//Calcular promedio de aceleración
		acelerationAvg = acelerationSum / x.length;
		
		if ((promedioZ > promedioY && SMA > 1400 && SMA < 2300)){
			//&& (Main.collmotor != null && Main.collmotor.txtActividad != null)
			//Celular detenido horizontalmente
			result = "El celular se encuentra detenido horizontalmente...";
			ProxyDataActivity pd = new ProxyDataActivity(service, 1, 2);
			pd.start();
		} else if ((promedioY > promedioZ)) {
			if (acelerationAvg < 10) {
				if (desviacionX < 1 && desviacionY < 1 && desviacionZ < 1) {
					//Detenido viendo el celular
					//if (Main.collmotor != null && Main.collmotor.txtActividad != null) 
					result = "Detenido viendo el celular...";
					ProxyDataActivity pd = new ProxyDataActivity(service, 5, 2);
					pd.start();
				} else {
					//Caminando 
					//if (Main.collmotor != null && Main.collmotor.txtActividad != null) 
					//Caminando
					result = "Caminando...";
					ProxyDataActivity pd = new ProxyDataActivity(service, 2, 2);
					pd.start();
				}
			} else {
				//Corriendo
				//if (Main.collmotor != null && Main.collmotor.txtActividad != null)
				result = "Corriendo...";
				ProxyDataActivity pd = new ProxyDataActivity(service, 3, 2);
				pd.start();
			}
		} else {
			if ((promedioY < promedioZ) && acelerationAvg < 10) {
				if (desviacionX < 1 && desviacionY < 1 	&& desviacionZ < 1) {
					// Detenido viendo cel
					//if (Main.collmotor != null && Main.collmotor.txtActividad != null)
					result = "Detenido viendo el celular...";
					ProxyDataActivity pd = new ProxyDataActivity(service, 5, 2);
					pd.start();
				} else {
					// Caminando viendo cel
					//if (Main.collmotor != null && Main.collmotor.txtActividad != null)
					result = "Caminando viendo el celular...";
					ProxyDataActivity pd = new ProxyDataActivity(service, 4, 2);
					pd.start();
				}
			}
		}
		return result;
	}
	//Algoritmo modificado para Sensors que recibe x,y,z del acelerómetro
	public String physicalActivityRecognitionV2(double x[], double y[], double z[]){
		String result = "Nothing...";
		
		double promedioX = calcularPromedio(x);
		double promedioY = calcularPromedio(y);
		double promedioZ = calcularPromedio(z);
		
		//////////////////////////////////////////
		//// Valores obtenidos del experimento ////
		//Detenido en superficie plana
		double pX_DetenidoSP = -0.076132697; 
		double dX_DetenidoSP = 0.086181948;
		double pY_DetenidoSP = 0.148521; 
		double dY_DetenidoSP = 0.0630772; 
		double pZ_DetenidoSP = 9.456258185; 
		double dZ_DetenidoSP = 0.108093296; //dZ_DetenidoSP += pZ_DetenidoSP * error;
		///////////////////////////////////////////
		///Caminando viendo celular
		double pX_CaminandoVC = -0.284932199;
		double dX_CaminandoVC = 1.100607196;
		double pY_CaminandoVC = 5.4143533;
		double dY_CaminandoVC = 1.79353269;
		double pZ_CaminandoVC = 8.281029225;
		double dZ_CaminandoVC = 1.641371075;					
		///////////////////////////////////////////
		///De pie detenido viendo celular
		double pX_DepieVC = -0.460863508;
		double dX_DepieVC = 0.153407015;
		double pY_DepieVC = 9.35461244;
		double dY_DepieVC = 0.115577257;
		double pZ_DepieVC = 2.07072312;
		double dZ_DepieVC = 9.596559347;	
		///////////////////////////////////////////
		///Corriendo
		double pX_Corriendo = 5.525507694;
		double dX_Corriendo = 4.328760102;
		double pY_Corriendo = 7.213183246;
		double dY_Corriendo = 4.818112233;
		double pZ_Corriendo = 3.399573235;
		double dZ_Corriendo = 3.326247873;	
		///////////////////////////////////////////
		//// Definición de límites
		//////////////////////////////////////////
		double limInferiorX_DetenidoSP = pX_DetenidoSP - dX_DetenidoSP;
		double limSuperiorX_DetenidoSP = pX_DetenidoSP + dX_DetenidoSP;
		double limInferiorY_DetenidoSP = pY_DetenidoSP - dY_DetenidoSP;	
		double limSuperiorY_DetenidoSP = pY_DetenidoSP + dY_DetenidoSP;	
		double limInferiorZ_DetenidoSP = pZ_DetenidoSP - dZ_DetenidoSP;
		double limSuperiorZ_DetenidoSP = pZ_DetenidoSP + dZ_DetenidoSP;			
		
		double limInferiorX_CaminandoVC = pX_CaminandoVC - dX_CaminandoVC;
		double limSuperiorX_CaminandoVC = pX_CaminandoVC + dX_CaminandoVC;
		double limInferiorY_CaminandoVC = pY_CaminandoVC - dY_CaminandoVC;
		double limSuperiorY_CaminandoVC = pY_CaminandoVC + dY_CaminandoVC;
		double limInferiorZ_CaminandoVC = pZ_CaminandoVC - dZ_CaminandoVC;
		double limSuperiorZ_CaminandoVC = pZ_CaminandoVC + dZ_CaminandoVC;
	
		double limInferiorX_DepieVC = pX_DepieVC - dX_DepieVC;
		double limSuperiorX_DepieVC = pX_DepieVC + dX_DepieVC;
		double limInferiorY_DepieVC = pY_DepieVC - dY_DepieVC;
		double limSuperiorY_DepieVC = pY_DepieVC + dY_DepieVC;
		double limInferiorZ_DepieVC = pZ_DepieVC - dZ_DepieVC;	
		double limSuperiorZ_DepieVC = pZ_DepieVC + dZ_DepieVC;
	
		double limInferiorX_Corriendo = pX_Corriendo - dX_Corriendo;
		double limSuperiorX_Corriendo = pX_Corriendo + dX_Corriendo;
		double limInferiorY_Corriendo = pY_Corriendo - dY_Corriendo;
		double limSuperiorY_Corriendo = pY_Corriendo + dY_Corriendo;
		double limInferiorZ_Corriendo = pZ_Corriendo - dZ_Corriendo;
		double limSuperiorZ_Corriendo = pZ_Corriendo + dZ_Corriendo;
	
		//Toast.makeText(Main.collmotor, "PromedioX: " + promedioX, Toast.LENGTH_LONG).show();
		//Toast.makeText(Main.collmotor, "Desviación X: " + calcularDesviacionEstandar(promedioX,x), Toast.LENGTH_LONG).show();
		//Toast.makeText(Main.collmotor, "PromedioY: " + promedioY, Toast.LENGTH_LONG).show();
		//Toast.makeText(Main.collmotor, "Desviación Y: " + calcularDesviacionEstandar(promedioY,y), Toast.LENGTH_LONG).show();
		//Toast.makeText(Main.collmotor, "PromedioZ: " + promedioY, Toast.LENGTH_LONG).show();
		//Toast.makeText(Main.collmotor, "Desviación Z: " + calcularDesviacionEstandar(promedioZ,z), Toast.LENGTH_LONG).show();
			
		//Algoritmo versión 2 (tomando en cuenta media y desviación estándar (error))	
		if ((limInferiorX_DetenidoSP <= promedioX && limSuperiorX_DetenidoSP >= promedioX) && 
			(limInferiorY_DetenidoSP <= promedioY && limSuperiorY_DetenidoSP >= promedioY) &&
			(limInferiorZ_DetenidoSP <= promedioZ && limSuperiorZ_DetenidoSP >= promedioZ)
			){
			result = "El celular se encuentra detenido horizontalmente";	
			ProxyDataActivity pd = new ProxyDataActivity(service, 1, 2);
			pd.start();
		}else if 
			((limInferiorX_CaminandoVC <= promedioX && limSuperiorX_CaminandoVC >= promedioX) && 
			(limInferiorY_CaminandoVC <= promedioY && limSuperiorY_CaminandoVC >= promedioY) &&
			(limInferiorZ_CaminandoVC <= promedioZ && limSuperiorZ_CaminandoVC >= promedioZ)
		){
			result = "Caminando viendo el celular";	
			ProxyDataActivity pd = new ProxyDataActivity(service, 4, 2);
			pd.start();
		}else if 
			((limInferiorX_DepieVC <= promedioX && limSuperiorX_DepieVC >= promedioX) && 
			(limInferiorY_DepieVC <= promedioY && limSuperiorY_DepieVC >= promedioY) &&
			(limInferiorZ_DepieVC <= promedioZ && limSuperiorZ_DepieVC >= promedioZ)
		){
			result = "Detenido viendo el celular";			
			ProxyDataActivity pd = new ProxyDataActivity(service, 5, 2);
			pd.start();
		}else if 
			((limInferiorX_Corriendo <= promedioX && limSuperiorX_Corriendo >= promedioX) && 
			(limInferiorY_Corriendo <= promedioY && limSuperiorY_Corriendo >= promedioY) &&
			(limInferiorZ_Corriendo <= promedioZ && limSuperiorZ_Corriendo >= promedioZ)
		){
			result = "Corriendo";
			ProxyDataActivity pd = new ProxyDataActivity(service, 3, 2);
			pd.start();
		}
		return result;
	}
	
	
	@Override
	public void onSensorChanged(SensorEvent event) {
		// Cada sensor puede provocar que un thread pase por aquí, así que
		// hay que sincronizar el acceso
		synchronized (this) {
			switch (event.sensor.getType()) {
			case Sensor.TYPE_ACCELEROMETER:	
				//La lectora del acelerómetro debe llenar la tabla de lecturas
				//La ventana es de 200 lecturas aprox., los valores son colocados en una matriz de 200 filas (lecturas) 3 columnas (x,y,z).
				if (tiempo_inicial == 0) {
					tiempo_inicial = System.currentTimeMillis();
					tiempo_final = System.currentTimeMillis();
				}else
					tiempo_final = System.currentTimeMillis();
				
				for (int i = 0; i < mAccelerometerValues.length; i++) 
					mAccelerometerValues[i] = event.values[i];
				
				//double diffSec = (tiempo_final - tiempo_inicial) * (0.001);
				//diffSec < 9 || 
				//Si las 200 lecturas de la ventana no se cumplen entonces se sigue leyendo la información
				if ((CollMotor.row < 200) && mAccelerometerValues.length == 3) {	
						CollMotor.accelerometerX[CollMotor.row] = mAccelerometerValues[0];
						CollMotor.accelerometerY[CollMotor.row] = mAccelerometerValues[1];
						CollMotor.accelerometerZ[CollMotor.row] = mAccelerometerValues[2];
						
						CollMotor.row++;

						boolean sync_ac_local = Main.prefs.getBoolean("sync_ac_local", false);
						boolean sync_ac_server = Main.prefs.getBoolean("sync_ac_server", false);
						
						if (sync_ac_local) {
							ContentValues values = new ContentValues();
							values.put("x", mAccelerometerValues[0]);
							values.put("y", mAccelerometerValues[1]);
							values.put("z", mAccelerometerValues[2]);
							values.put("date", android.text.format.DateFormat.format("yyyy-MM-dd hh:mm:ss", new java.util.Date()).toString());
							Main.myDbHelper.insert("accelerometer_info", values);
						}
				
						if (sync_ac_server) {
							ProxyDataAxis pd = new ProxyDataAxis(2, 1, mAccelerometerValues[0], mAccelerometerValues[1], mAccelerometerValues[2]);
							pd.start();
						}
				}else{
					//Ejecución del algoritmo versión 1	
					//Lo siguiente es para que el Algoritmo versión 1 sea ejecutado(efectivo/no optimizado)
					String actividad = physicalActivityRecognitionV1(CollMotor.accelerometerX, CollMotor.accelerometerY, CollMotor.accelerometerZ);
					Main.collmotor.txtActividad.setText(actividad);
					
					
					//Ejecución del algoritmo versión 2
					//Más organizado menos efectivo
					//****Si se quiere utilizar el algoritmo v2 del artículo sensors descomentar lo siguiente 
					//********************************************************************************************************
					//String actividad = physicalActivityRecognitionv2(CollMotor.accelerometerX, CollMotor.accelerometerY, CollMotor.accelerometerZ);
					//Main.collmotor.txtActividad.setText(actividad);
					//********************************************************************************************************
				
					
					
					CollMotor.row = 0;
					tiempo_inicial = System.currentTimeMillis();
					tiempo_final = System.currentTimeMillis();
				}
				break;
			case Sensor.TYPE_MAGNETIC_FIELD:
				for (int i = 0; i < 3; i++) 
					mMagneticValues[i] = event.values[i];
				break;
			default:
				
			}
		}
	}
}

class ProxyDataActivity extends Thread {
	private int idPhysicalActivity, idActor;
	Main service;

	public ProxyDataActivity(Main service, int idPhysicalActivity, int idActor) {
		this.idPhysicalActivity = idPhysicalActivity;
		this.idActor = idActor;
		this.service = service;
	}

	public void run() {
		boolean sync_ap_server = false;
		sync_ap_server = Main.prefs.getBoolean("sync_ap_server", false);

		if (sync_ap_server) {
			try {

				ActivityAccelerometerWebService testWS = new ActivityAccelerometerWebService(Main.ip);
				testWS.ActivityAccelerometerInfo(this.idPhysicalActivity, this.idActor);
			} catch (Exception e) {
			}
		}
	}
}

class ProxyDataAxis extends Thread {
	private int idActor, idDevice;
	private float x, y, z;

	public ProxyDataAxis(int idActor, int idDevice, float x, float y, float z) {
		this.idActor = idActor;
		this.idDevice = idDevice;
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public void run() {
		try {
			AccelerometerWebService testWS = new AccelerometerWebService(Main.ip);
			testWS.AccelerometerInfo(idActor, idDevice, x, y, z);
		} catch (Exception e) {
		}

	}
	
}
