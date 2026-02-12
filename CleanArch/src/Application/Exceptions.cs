namespace Application;

public class RequestValidationException(string message)
    : Exception(message);

public class EntityNotFoundException(string message = "Entity not found.")
    : Exception(message);