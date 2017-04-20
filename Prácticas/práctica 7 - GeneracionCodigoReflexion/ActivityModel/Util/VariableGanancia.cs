using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operaciones.ActivityModel.Util
{
    public class VariableGanancia : Base
    {

        public string variable { get; set; }
        public string value { get; set; }
        public Signo signo { get; set; }
        public double pGanancia { get; set; }
        public TipoVariable tipo { get; set; }
        public TipoEscala escala { get; set; }
        public List<VariableGanancia> ganancia { get; set; }

        public VariableGanancia()
        {
            ganancia = new List<VariableGanancia>();
        }

        public void AgregarGanancia(VariableGanancia g){
            ganancia.Add(g);
        }
        public void GenerarGanancias(List<VariableGanancia> g, double pGanancia)
        {
            foreach (VariableGanancia g1 in ganancia){
                 g1.pGanancia = pGanancia;
                if (g1.ganancia.Count() != 0)
                    GenerarGanancias(g1.ganancia, pGanancia);
            }
        }

        public static List<string> GananciasPositivasVariable(List<VariableGanancia> g, List<string> variables)
        {
            foreach (VariableGanancia g1 in g)
            {
                if (g1.signo == Signo.POSITIVO)
                {   variables.Add(g1.Name);

                if (g1.ganancia.Count() != 0)
                {
                    return GananciasPositivasVariable(g1.ganancia, variables);

                }
                }
            }
            return variables;
        }

        public static List<string> GananciasNegativasVariable(List<VariableGanancia> g, List<string> variables)
        {
            foreach (VariableGanancia g1 in g)
            {
                if (g1.signo == Signo.NEGATIVO)
                {
                    variables.Add(g1.Name);

                    if (g1.ganancia.Count() != 0)
                    {
                        return GananciasNegativasVariable(g1.ganancia, variables);
                    }
                }
            }
            return variables;
        }

        public static List<string> GananciasNeutralesVariable(List<VariableGanancia> g, List<string> variables)
        {
            foreach (VariableGanancia g1 in g)
            {
                if (g1.signo == Signo.NEUTRAL)
                {
                    variables.Add(g1.Name);

                    if (g1.ganancia.Count() != 0)
                    {
                        return GananciasNeutralesVariable(g1.ganancia, variables);
                    }
                }
            }
            return variables;
        }

        public double SumarGananciasPositivasVariable(List<VariableGanancia> g, double result,string variable, bool b)
        {   
            foreach (VariableGanancia g1 in g)
            {
                 if (g1.signo == Signo.POSITIVO)
                    result += g1.pGanancia;

                 var q = (from t in g
                          where t.Name.Equals(variable)
                          select t);
                 if (q.Count() == 1)
                 {
                     b = true;
                     return result;
                 }
                 if (g1.ganancia.Count() != 0 && !b)
                 {
                     double resulttmp = SumarGananciasPositivasVariable(g1.ganancia, result, variable, b);
                     if (resulttmp != result)
                         b = true;
                     result = resulttmp;
                 }
            }
            return result;
        }

        public double SumarGananciasNegativasVariable(List<VariableGanancia> g, double result, string variable, bool b)
        {
            foreach (VariableGanancia g1 in g)
            {
              
                if (g1.signo == Signo.NEGATIVO)
                    result += g1.pGanancia;
                var q = (from t in g
                         where t.Name.Equals(variable)
                         select t);
                if (q.Count() == 1)
                {
                    b = true;
                    return result;
                }
                if (g1.ganancia.Count() != 0 && !b)
                {
                    double resulttmp = SumarGananciasNegativasVariable(g1.ganancia, result, variable, b);
                    if (resulttmp != result)
                        b = true;
                    result = resulttmp;
                }
            }
            return result;
        }

        public double SumarGananciasNeutralesVariable(List<VariableGanancia> g, double result, string variable, bool b)
        {
            foreach (VariableGanancia g1 in g)
            {

                if (g1.signo == Signo.NEUTRAL)
                    result += g1.pGanancia;
                var q = (from t in g
                         where t.Name.Equals(variable)
                         select t);
                if (q.Count() == 1)
                {
                    b = true;
                    return result;
                }
                if (g1.ganancia.Count() != 0 && !b)
                    result = SumarGananciasNeutralesVariable(g1.ganancia, result, variable, b);
            }
            return result;
        }

        public double SumarGananciasPositivas(List<VariableGanancia> g, double result)
        {
            foreach (VariableGanancia g1 in ganancia)
            {
                if (g1.signo == Signo.POSITIVO)
                   result += g1.pGanancia;
                if (g1.ganancia.Count() != 0)
                    result = SumarGananciasPositivas(g1.ganancia, result);
            }
            return result;
        }

        public double SumarGananciasNegativas(List<VariableGanancia> g, double result)
        {
            foreach (VariableGanancia g1 in ganancia)
            {
                if (g1.signo == Signo.NEGATIVO)
                    result += g1.pGanancia;
                if (g1.ganancia.Count() != 0)
                    result = SumarGananciasNegativas(g1.ganancia, result);
            }
            return result;
        }

        public double SumarGananciasNeutrales(List<VariableGanancia> g, double result)
        {
            foreach (VariableGanancia g1 in ganancia)
            {
                if (g1.signo == Signo.NEUTRAL)
                    result += g1.pGanancia;
                if (g1.ganancia.Count() != 0)
                    result = SumarGananciasNeutrales(g1.ganancia, result);
            }
            return result;
        }
    }
}
