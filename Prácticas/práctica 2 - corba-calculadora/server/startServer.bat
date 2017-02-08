@echo off
REM Iniciar el servidor
REM Clase Tópicos Selectos de Computación I 
REM Luis G. Montané Jiménez 

SET CLASSPATH=%CLASSPATH%;../idl/Calculadora.jar;../idl/Calculadora.jar;../../Recursos/ConexionMiniFramework/frameworkmini.jar;
echo ********************************************************
echo Ejecutando servidor!!!!!
java CalculadoraServer -ORBInitialPort 2000 -ORBInitialHost localhost