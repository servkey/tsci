@echo off
REM Iniciar el cliente
REM Clase T�picos Selectos de Computaci�n I 
REM Luis G. Montan� Jim�nez 

SET CLASSPATH=%CLASSPATH%;../idl/Calculadora.jar
echo ********************************************************
java ClientTest -ORBInitialPort 2000 -ORBInitialHost localhost
pause > nul