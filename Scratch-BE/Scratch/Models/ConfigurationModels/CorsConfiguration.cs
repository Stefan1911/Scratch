using System.Collections.Generic;

namespace Scratch.Models.ConfigurationModels
{
    public class CorsConfiguration
    {
        public string Name { get; set; }
		public IEnumerable<string> Origins { get; set; }

		
    }
}