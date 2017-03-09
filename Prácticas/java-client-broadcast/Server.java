import java.io.*;
import java.net.*;

class Server
{
   public static void main(String args[]) throws Exception
      {
       	    DatagramSocket serverSocket = new DatagramSocket(1234);
            byte[] datosRecibidos = new byte[1024];
            byte[] datosEnviados = new byte[1024];
            while(true)
               {
                  DatagramPacket paqueteRecibido = new DatagramPacket(datosRecibidos, datosRecibidos.length);
                  serverSocket.receive(paqueteRecibido);
                  String mensaje = new String(paqueteRecibido.getData());
                  System.out.println("Recibido del cliente: " + mensaje);
                  InetAddress IPAddress = paqueteRecibido.getAddress();
                  int puerto = paqueteRecibido.getPort();
		  String mensajeModificado = " [modificado]";

                  datosEnviados = mensajeModificado.getBytes();

                  System.out.println("Enviando desde el server: " + mensajeModificado );

                  DatagramPacket enviarPaquete =
                  new DatagramPacket(datosEnviados, datosEnviados.length, IPAddress, puerto);
                  serverSocket.send(enviarPaquete);
               }
      }
}