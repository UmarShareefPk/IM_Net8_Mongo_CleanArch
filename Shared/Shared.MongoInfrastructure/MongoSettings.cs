﻿namespace Shared.MongoInfrastructure
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; } = default!;
        public string DatabaseName { get; set; } = default!;
    }
}
