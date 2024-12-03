﻿namespace BabyCradle.DTO
{
    public class EditNoteDTO
    {
        public string Title { get; set; } = string.Empty;

        public string? Content { get; set; } = string.Empty;

        [FutureDate]
        public DateTime NotificationTime { get; set; }

    }
}