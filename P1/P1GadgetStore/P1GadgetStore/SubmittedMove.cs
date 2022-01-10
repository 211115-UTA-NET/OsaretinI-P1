using System;
using System.ComponentModel.DataAnnotations;
namespace P1GadgetStore
{
    public class SubmittedMove
    {
        [Required]
        //[StringLength(100, MinimumLength = 5)]
        public string? Player1Name { get; set; }

        [Required]
        public string? Player2Name { get; set; }

        [Required]
        public Move Move { get; set; }
    }
}

