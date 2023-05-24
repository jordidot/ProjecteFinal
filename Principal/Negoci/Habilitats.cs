using Principal.Connexions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Principal.Negoci
{
    public class Habilitats
    {
        //Atributs i propietats
        public List<Habilitat> LListahabilitats { get; set; }
        //Constructors
        public Habilitats()
        {
            LListahabilitats = new List<Habilitat>();
        }
        public Habilitats(List<Habilitat> list)
        {
            this.LListahabilitats = list;
        }
        //Metodes 
        /// <summary>
        /// Mètode de la classe Habilitats que crida a la classe HabilitatsDB per afegir una habilitat a la base de dades.
        /// </summary>
        /// <param name="habilitat">Classe Habilitat amb l'informació d'aquesta.</param>
        public void AfegirHabilitat(Habilitat habilitat)
        {
            HabilitatsDB habilitatsdb = new();
            habilitatsdb.AfegirHabilitatBD(habilitat);

        }
        /// <summary>
        /// Mètode de la classe Habilitats que crida a la classe HabilitatsDB per eliminar una habilitat a la base de dades.
        /// </summary>
        /// <param name="habilitat">Classe Habilitat amb l'informació d'aquesta.</param>
        public void EliminarHabilitat(Habilitat habilitat)
        {
            HabilitatsDB habilitatsdb = new();
            habilitatsdb.EliminarHabilitatBD(habilitat);
        }
        /// <summary>
        /// Mètode de la classe Habilitats que crida a la classe HabilitatsDB per modificar habilitats a la base de dades.
        /// </summary>
        /// <param name="habilitats">Classe Habilitats amb una llista de Habilitat amb l'informació d'aquestes.</param>
        public void ModificarHabilitats(Habilitats habilitats)
        {
            HabilitatsDB habilitatsdb = new();
            habilitatsdb.ModificarHabilitats(habilitats);
        }
        /// <summary>
        /// Mètode de la classe Habilitats que crida a la classe HabilitatsDB per recuperar totes les habilitats de la base de dades.
        /// </summary>
        /// <returns>Retorna una llista d'Habilitat amb imformació de la base de dades.</returns>
        public List<Habilitat> RecuperarHabilitats()
        {
            HabilitatsDB habilitatsdb = new();
            habilitatsdb.RecuperarHabilitats();
            return habilitatsdb.Habilitats.LListahabilitats;
        }
    }
}
