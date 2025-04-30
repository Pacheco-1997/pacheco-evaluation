using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.Dtos
{
    public class RatingDto
    {
        /// <summary>
        /// Average rating value.
        /// </summary>
        [Range(0.0, 5.0)]
        public decimal Rate { get; set; }

        /// <summary>
        /// Number of ratings received.
        /// </summary>
        [Range(0, int.MaxValue)]
        public int Count { get; set; }
    }
}
