using DHSC.ANS.API.Consumer.DTOs;
using DHSC.ANS.API.Consumer.Models;

namespace DHSC.ANS.API.Consumer.Interfaces
{
    public interface IValidationService<T>
    {
        ValidationOutcome Validate(T instance);
    }
}
