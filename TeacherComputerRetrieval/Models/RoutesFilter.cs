namespace TeacherComputerRetrieval.Models
{
    public class RoutesFilter
    {
        //Can't have this as we could run into an infinite loop wherein we have loop inside graph/routes in academies
        //public int MinStops { get; set; }

        public int MaxStops { get; set; }

        public int Stops { get; set; }

        //Can't have this as we could run into an infinite loop wherein we have loop inside graph/routes in academies
        //public int MinDistance { get; set; }

        public int MaxDistance { get; set; }

        public int Distance { get; set; }
    }
}
