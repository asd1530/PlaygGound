namespace Common.Sie
{
    /// <summary>
    /// #KONTO
    /// </summary>
    
    public class SieAccount : BaseSieEntity
    {
        public SieAccount()
        {
            Name = "";
        }        
        public string Number { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string AccountType { get; set; }
       
    }
}
