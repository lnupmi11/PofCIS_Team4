namespace BusinessLogic
{
    public class Patient: Identified
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }
    }
}
