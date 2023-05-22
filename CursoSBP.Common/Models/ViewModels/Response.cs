﻿namespace CursoSBP.Common.Models.ViewModels
{
    public class Response<T> where T : class
    {
        public bool IsSuccess { get; set; }

        public string? Message { get; set; }

        public T Result { get; set; } = null!;
    }
}
