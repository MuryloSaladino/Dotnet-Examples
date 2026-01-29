namespace Infrastructure;

public class ConfigurationException(string configName)
    : Exception($"Invalid configuration: {configName}");

public class DatabaseException(string message)
    : Exception(message);
        
public class EntityNotFoundException(string message = "Entity not found.")
    : Exception(message);

public class DuplicatedEntityException(string message)
    : Exception(message);