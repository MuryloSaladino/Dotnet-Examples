namespace Application;

public class RequestValidationException(string details)
    : Exception($"One or more validation errors occurred. {details}");

public class EntityNotFoundException(string message = "Entity not found.")
    : Exception(message);