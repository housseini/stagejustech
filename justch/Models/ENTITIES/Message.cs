namespace justch.Models.ENTITIES
{
    public class Message
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Message (bool s,string m)
        {
            this.message = m;
            this.status = s;

        }

    }
}
