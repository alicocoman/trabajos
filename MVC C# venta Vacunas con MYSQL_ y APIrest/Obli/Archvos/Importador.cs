using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesNegocio;
using Repositorios;

namespace Archvos
{
    public class Importador
    {
        
            public IEnumerable<Usuario> UsuDeTexto()
            {
                IEnumerable<Usuario> losUsu =Manejo.crearListaUsu();
                return losUsu;
            }
            public IEnumerable<Laboratorio> LabDeTexto()
            {

                IEnumerable<Laboratorio> losLabo = Manejo.crearListaLab();
                return losLabo;
            }

            public IEnumerable<TipoVacuna> TVacDeTexto()
            {

                IEnumerable<TipoVacuna> losTipos = Manejo.crearListaTVac();
                return losTipos;
            }

           

            public IEnumerable<Vacuna> VacDeTexto()
            {
                IEnumerable<Vacuna> lasVac = Manejo.crearListaVac();
                return lasVac;

            }

        }
    }
