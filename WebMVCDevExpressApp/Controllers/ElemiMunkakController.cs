using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMVCDevExpressApp.Models;

namespace WebMVCDevExpressApp.Controllers
{
    public class ElemiMunkakController : ApiController
    {
        // GET: api/ElemiMunkak
        public IQueryable<ElemiMunka> GetElemiMunkak()
        {
            return ElemiMunka.GetElemiMunkak( 0, 20 );
        }


        public IQueryable<ElemiMunka> GetElemiMunkak(int skip, int take)
        {
            return ElemiMunka.GetElemiMunkak(skip, take);
        }

        [Route("api/ElemiMunkak/TotalCount")]
        public int GetTotalCount()
        {
            return ElemiMunka.GetElemiMunkakCount();
        }

        public IQueryable<ElemiMunka> GetElemiMunkak( int id )
        {
            return ElemiMunka.GetElemiMunkak( 0,1);
        }

    }
}
