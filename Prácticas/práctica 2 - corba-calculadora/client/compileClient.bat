@echo off
REM Compilar cliente CORBA
REM Clase T�picos Selectos de Computaci�n I 
REM Luis G. Montan� Jim�nez 
echo ******************************************************
echo Limpiando archivos compilados anteriormente
SET CLASSPATH=%CLASSPATH%;../idl/Calculadora.jar
SET ARCHIVO_JAR=Calculadora.jar

IF NOT EXIST *.class GOTO terminar
del *.class

:terminar
echo Compilando clases del cliente!!!
javac *.java
echo Finalizando compilaci�n del cliente!!!
pause > nul