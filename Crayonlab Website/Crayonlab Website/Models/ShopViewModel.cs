using System.Collections.Generic;

namespace Crayonlab.Models
{
	public class ShopViewModel
	{
		public IEnumerable<Designs> Designs { get; set; }
		public IEnumerable<BasketballJersey> BasketballJerseys { get; set; }
        public IEnumerable<Longsleeve> Longsleeves { get; set; }
        public IEnumerable<Soccerjersey> Soccerjerseys { get; set; }
        public IEnumerable<Partners> Partners { get; set; }
    }
}
