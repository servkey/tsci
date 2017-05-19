package com.collmotorac;

import org.ksoap2.*;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

public class ActivityAccelerometerWebService extends WebServiceBase{	
	public ActivityAccelerometerWebService(String ip){
		URL = "http://" + ip +  URL;
		METHOD_NAME = "InsertActivityByAccelerometer";
		SOAP_ACTION = NAMESPACE + METHOD_NAME;
	}
	
	public boolean ActivityAccelerometerInfo(int idPhysicalActivity,int idActor) throws Exception {		
		boolean r = false;
		String result = "false";
		SoapObject request = new SoapObject(NAMESPACE, METHOD_NAME);			
	   
		request.addProperty("idPhysicalActivity", String.valueOf(idPhysicalActivity));
		request.addProperty("idActor", String.valueOf(idActor));		
		
	    final SoapSerializationEnvelope envelope =
		new SoapSerializationEnvelope(SoapEnvelope.VER11);
		envelope.dotNet = true;
		envelope.setOutputSoapObject(request);
		HttpTransportSE androidHttpTransport = new HttpTransportSE(URL);
	
		try
		{
			androidHttpTransport.call(SOAP_ACTION, envelope);
			result = ((SoapPrimitive)envelope.getResponse()).toString();
			
		}catch(Exception e) 
		{
			throw e;
		}
		
		r = result.equals("true")?true:false;
		return r;
	}
}
