﻿namespace plagiarismModel
{
    public class UserImages
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte[] Image { get; set; }
        public byte[] ImageThumb { get; set; }
    }
}
