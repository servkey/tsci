Pr�ctica CORBA
T�picos Selectos de Computaci�n I
Luis G. Montan� Jim�nez


Requerimientos:
	JDK, configuraci�n de variables de entorno para el comando javac, java, idlj, etc. (PATH,CLASS_PATH)

**Desde consola CMD***
Pasos para compilaci�n:
	
	Dentro de la carpeta "/idl" compilar la interfaz idl con el comando:
		compileIdl.bat
	Dentro de la carpeta "/server" compilar el servidor con el comando:
		compileServer.bat
	Dentro de la carpeta  "/client" compilar el cliente con el comando:
		compileClient.bat

Pasos para ejecuci�n:
	1) Dentro de la carpeta "/server" iniciar el servicio para corba con:
		startService.bat
	
	
	2) Para la ejecuci�n del servidor, en la carpeta"/server" lanzar el comando:
		startServer.bat
	 	*Para el siguiente paso necesitar� abrir otra consola y ubicarse en la carpeta "client".

	3) Dentro de la carpeta cliente probar la ejecuci�n con:
		startClient.bat