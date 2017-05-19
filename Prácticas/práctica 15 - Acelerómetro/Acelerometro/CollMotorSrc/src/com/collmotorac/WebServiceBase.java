package com.collmotorac;

public abstract class WebServiceBase{
	protected String NAMESPACE = "http://groupwareFei.org/" ;
	protected String URL = "/GFei/GroupwareService.asmx";
	protected String SOAP_ACTION = "http://groupwareFei.org/InsertAccelerometerInfo";
	protected String METHOD_NAME = "InsertAccelerometerInfo";
	
	public WebServiceBase(){
	}
	
	public WebServiceBase(String namespace, String ip, String soapAction, String method){
		NAMESPACE = namespace;
		SOAP_ACTION = soapAction;
		METHOD_NAME = method;
		URL = "http://" + ip +  URL;   	 	
	}
}
