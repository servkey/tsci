package com.collmotorac;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

public class MeasureWebService extends WebServiceBase{
	
	public MeasureWebService(String namespace, String ip, String soapAction, String method) {
		super(namespace, ip, soapAction + method, method);
	}
	
	public boolean AddMeasure(float cpuUSR, float cpuSYS, float batteryLevel, float batteryTemperature) throws Exception {		
		boolean r = false;
		String result = "false";
		System.out.println(NAMESPACE);
		System.out.println(METHOD_NAME);		
		SoapObject request = new SoapObject(NAMESPACE, METHOD_NAME);  
		request.addProperty("cpuUSR", String.valueOf(cpuUSR));
		request.addProperty("cpuSYS", String.valueOf(cpuSYS));
		request.addProperty("batteryLevel", String.valueOf(batteryLevel));
		request.addProperty("batteryTemperature", String.valueOf(batteryTemperature));
	
	    final SoapSerializationEnvelope envelope =
		new SoapSerializationEnvelope(SoapEnvelope.VER11);
		envelope.dotNet = true;
		envelope.setOutputSoapObject(request);
		HttpTransportSE androidHttpTransport = new HttpTransportSE(URL);
		System.out.println("Intentando insertar datos! " + SOAP_ACTION);
		try
		{
			androidHttpTransport.call(SOAP_ACTION, envelope);
			result = ((SoapPrimitive)envelope.getResponse()).toString();
			
		}catch(Exception e) 
		{
			System.out.println("Ha ocurrido un error");
			throw e;
		}
		
		r = result.equals("true")?true:false;
		return r;
	}
}
