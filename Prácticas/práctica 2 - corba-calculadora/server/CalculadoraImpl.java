//Implementación del componente 
//Tópicos Selectos de Computación I
//Luis Gerardo Montané Jiménez

import org.omg.CORBA.*;
import org.omg.PortableServer.*;
import org.omg.PortableServer.POA;
import CalculadoraApp.*;

public class CalculadoraImpl extends CalculadoraPOA {
  private static int x = 0;
  private ORB orb;

  public void setORB(ORB orb_val) {
    orb = orb_val; 
  }
 
  public String saludar() {    
    return "\nSaludando desde el componente CORBA -> " + (x++) + "\n";
  }
    
  public int sumar(int x, int y) {
    return x + y;
  }
}