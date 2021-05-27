using System.IO;

namespace STEP_PAY.Models
{
    public class User
    {
        public string UserName { get; set; } = "Test";
        public byte[] Image { get; set; }

        public User()
        {
            Image = File.ReadAllBytes("./picture3.png");
        }
    }
}
