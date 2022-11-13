using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        //public IEnumerable<ValidationFailure>? Errors { get; set; } falta agregar fluentValidation para los modelos, creo que lo mejor es ponerlo en controlador antes de llamar al servicio
    }
}
