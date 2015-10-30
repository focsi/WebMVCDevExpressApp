using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebMVCDevExpressApp.Models
{
    public class ElemiMunka
    {
        public decimal AZONOSITO { get; set; }
        public string MAIN { get; set; }
        public string KESZULTSEG { get; set; }
        public string PRIORITAS { get; set; }
        public string IDO { get; set; }
        public string BEJSZ { get; set; }
        public string MUNKASZAM { get; set; }
        public string CIM { get; set; }
        public string START_IDO { get; set; }
        public decimal KOMPLEX_MUNKA_AZONOSITO { get; set; }
        public decimal SORSZAM { get; set; }
        public decimal STATUSZ { get; set; }
        public System.DateTime TERVEZETT_KEZDET_IDO { get; set; }
        public System.DateTime TERVEZETT_VEG_IDO { get; set; }
        public System.DateTime VEGREHAJTAS_KEZDET_IDO { get; set; }
        public System.DateTime VEGREHAJTAS_VEG_IDO { get; set; }
        public decimal KANORMTEV_AZONOSITO { get; set; }
        public decimal KOV_KOPRIO_AZONOSITO { get; set; }
        public string KOV_KANORMTEV_MEGNEVEZES { get; set; }
        public string KOV_KOPRIO_MEGNEVEZES { get; set; }
        public System.DateTime MUNKAKEZDES { get; set; }
        public System.DateTime MUNKABEFEJEZES { get; set; }
        public System.DateTime OSYSDATE { get; set; }
        public string MAIN_ICON { get; set; }
        public string ICON0 { get; set; }
        public string ICON1 { get; set; }

        public ElemiMunka()
        {
            DataSetMirtusz DB = new DataSetMirtusz();
            using (DataSetMirtuszTableAdapters.V_ELEMI_MUNKA_IN_M_LISTTableAdapter ta = new DataSetMirtuszTableAdapters.V_ELEMI_MUNKA_IN_M_LISTTableAdapter() )
            {
                ta.FillBy( DB.V_ELEMI_MUNKA_IN_M_LIST, 10);
            }
            foreach (var item in DB.V_ELEMI_MUNKA_IN_M_LIST.AsQueryable() )
            {
                ;
            }
        }

        public static IQueryable<ElemiMunka> GetElemiMunkak( int skip, int take )
        {
            DataSetMirtusz DB = new DataSetMirtusz();
            using (DataSetMirtuszTableAdapters.V_ELEMI_MUNKA_IN_M_LISTTableAdapter ta = new DataSetMirtuszTableAdapters.V_ELEMI_MUNKA_IN_M_LISTTableAdapter())
            {
                ta.FillBy(DB.V_ELEMI_MUNKA_IN_M_LIST, 10000+1);
            }

            var page = DB.V_ELEMI_MUNKA_IN_M_LIST.OrderBy(em => em.AZONOSITO).Skip(skip).Take(take);
            return page.Select(dbe => new ElemiMunka()
            {
                AZONOSITO = dbe.AZONOSITO,
                CIM = dbe.CIM,
                MAIN = dbe.MAIN,
                KESZULTSEG =dbe.KESZULTSEG,
                PRIORITAS = dbe.PRIORITAS
            }
            ).AsQueryable();
        }

        public static int GetElemiMunkakCount()
        {
            DataSetMirtusz DB = new DataSetMirtusz();
            using (DataSetMirtuszTableAdapters.V_ELEMI_MUNKA_IN_M_LISTTableAdapter ta = new DataSetMirtuszTableAdapters.V_ELEMI_MUNKA_IN_M_LISTTableAdapter())
            {
                ta.FillBy(DB.V_ELEMI_MUNKA_IN_M_LIST, 10000 + 1);
            }

            return DB.V_ELEMI_MUNKA_IN_M_LIST.Count();
        }
    }


}