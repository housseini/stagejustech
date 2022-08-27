using System.Collections.Generic;

using justch.Models.BLL;

namespace justch.Models.ENTITIES
{
    public class CuveVisotubePaitelle
    {
        public List<Cuve> Cuves { get; set; } 
        public List<Visotube> visotubes { get; set; }
        public  List <Paillette> paillettes { get; set; }

        public CuveVisotubePaitelle()
        {
            var cu = BLL_Cuve.GETS() ;
            if (cu!=null){
                Cuves = new List<Cuve>();
                Cuves = cu;
                var vis = BLL_Visotube.GETS();
                if (vis != null)
                {
                    visotubes = new List<Visotube>();
                    visotubes = vis;

                    var pa = BLL_Paillette.GETS();
                    if (pa != null)
                    {
                        paillettes = new List<Paillette>();
                        paillettes = pa;
                    }
                }
            }
        }
    }
}
