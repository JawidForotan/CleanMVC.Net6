namespace SimpleMVC.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Question { get; set; }
    }
}
