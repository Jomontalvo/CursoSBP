using NetTopologySuite.Geometries;
using System.Collections.Generic;

namespace CursoSBP.Common.Models.Entities
{
    public class Campus
    {
        public int Id { get; set; }
        public string? CampusName { get; set; }
        public string? Address { get; }
        public Point? Geography { get; set; }
        public string? Url { get; set; } 
    }
}