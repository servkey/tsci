import java.io.*;
import java.net.*;

class Client
{
   public static void main(String args[]) throws Exception
   {
      DatagramSocket clientSocket = new DatagramSocket();
      InetAddress IPAddress = InetAddress.getByName("255.255.255.255");
      byte[] data = new byte[1024];
      byte[] dataRecibidos = new byte[1024];

      String mensaje = "[Enviando Texto Compartido]";
      data = mensaje.getBytes();
      DatagramPacket packet = new DatagramPacket(data, data.length, IPAddress, 1234);
      clientSocket.send(packet);

      System.out.println("Datos enviados: " + mensaje);
      DatagramPacket paqueteRecibido = new DatagramPacket(dataRecibidos, dataRecibidos.length);
      clientSocket.receive(paqueteRecibido);
      String mensajeRecibido = new String(paqueteRecibido.getData());
      System.out.println("Recibido desde el servidor:" + mensajeRecibido);

      clientSocket.close();
   }
}