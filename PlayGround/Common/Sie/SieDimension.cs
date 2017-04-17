using System.Collections.Generic;

namespace Common.Sie
{

    public class SieDimension : BaseSieEntity
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public bool IsDefault = false;

        private SieDimension _parent = null;
        public SieDimension SuperDim 
        { 
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
                _parent.SubDim.Add(this);
            } 
        }
        
        public IList<SieDimension> SubDim = new List<SieDimension>();
        
        public Dictionary<string, SieObject> Objects = new Dictionary<string, SieObject>();
        
    }
}
