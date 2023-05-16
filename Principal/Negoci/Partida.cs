using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Negoci
{
    public class Partida
    {
        //Atributs
        private int id;
        private Bot bot;
        private int botVida;
        private Cartes cartesBot;
        private Mazo mazoUsuari;
        private Usuari usuari;
        private int usuariVida;
        private string estatPartida;
        //Constructors
        /// <summary>
        /// Constructor ple
        /// </summary>
        /// <param name="bot">Atribut bot, prove de la classe bot</param>
        /// <param name="botVida">atribut botvida, indica la vida del bot</param>
        /// <param name="cartesBot">atribut cartesbot, prove de la classe cartes</param>
        /// <param name="mazoUsuari">atribut mazousuari, prove de la classe mazo</param>
        /// <param name="usuari">atribut usuari, prove de la classe usuari </param>
        /// <param name="usuariVida">atribut usuarivida, indica la vida del usuari</param>
        public Partida(int id, Bot bot, int botVida, Cartes cartesBot, Mazo mazoUsuari, Usuari usuari, int usuariVida, string estatPartida)
        {
            this.id = id;
            this.bot = bot;
            this.botVida = botVida;
            this.cartesBot = cartesBot;
            this.mazoUsuari = mazoUsuari;
            this.usuari = usuari;
            this.usuariVida = usuariVida;
            this.estatPartida = estatPartida;
        }
        //Propietats
        /// <summary>
        /// Propietat de l'id
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Propietat del atribut bot
        /// </summary>
        public Bot Bot
        {
            get { return bot; }
            set { bot = value; }
        }
        /// <summary>
        /// Propietat del atribut vidabot
        /// </summary>
        public int BotVida
        {
            get { return botVida; }
            set { botVida = value; }
        }
        /// <summary>
        /// Propietat del atribut cartesdelbot
        /// </summary>
        public Cartes CartesBot
        {
            get { return cartesBot; }
            set { cartesBot = value; }
        }
        /// <summary>
        /// Propietat del atribut mazousuari
        /// </summary>
        public Mazo MazoUsuari
        {
            get { return mazoUsuari; }
            set { mazoUsuari = value; }
        }
        /// <summary>
        /// Propietat del atribut usuari
        /// </summary>
        public Usuari Usuari
        {
            get { return usuari; }
            set { usuari = value; }
        }
        /// <summary>
        /// Propietat del atribut usuarivida
        /// </summary>
        public int UsuariVida
        {
            get { return usuariVida; }
            set { usuariVida = value; }
        }
        /// <summary>
        /// Propietat del atribut estat de la partida
        /// </summary>
        public string EstatPartida
        {
            get { return estatPartida; }
            set { estatPartida = value; }
        }
    }
}
