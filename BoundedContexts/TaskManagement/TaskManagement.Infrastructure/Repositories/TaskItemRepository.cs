using AutoMapper;
using MongoDB.Driver;
using Shared.MongoInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Repositories;
using TaskManagement.Infrastructure.MongoModels;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly IMongoCollection<TaskItemDocument> _collection;
        private readonly IMapper _mapper;

        public TaskItemRepository(IMongoDbContext context, IMapper mapper)
        {
            _collection = context.GetCollection<TaskItemDocument>("task_items");
            _mapper = mapper;
        }

        public async Task<TaskItem?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var doc = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
            return doc is null ? null : _mapper.Map<TaskItem>(doc);
        }

        public async Task<List<TaskItem>> GetAssignedToAsync(string userId, CancellationToken cancellationToken = default)
        {
            var docs = await _collection.Find(x => x.AssignedTo == userId).ToListAsync(cancellationToken);
            return _mapper.Map<List<TaskItem>>(docs);
        }

        public async Task<List<TaskItem>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var docs = await _collection.Find(_ => true).ToListAsync(cancellationToken);
            return _mapper.Map<List<TaskItem>>(docs);
        }

        public async Task AddAsync(TaskItem taskItem, CancellationToken cancellationToken = default)
        {
            var doc = _mapper.Map<TaskItemDocument>(taskItem);
            await _collection.InsertOneAsync(doc, cancellationToken: cancellationToken);
        }

        public async Task UpdateAsync(TaskItem taskItem, CancellationToken cancellationToken = default)
        {
            var doc = _mapper.Map<TaskItemDocument>(taskItem);
            await _collection.ReplaceOneAsync(x => x.Id == doc.Id, doc, cancellationToken: cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            await _collection.DeleteOneAsync(x => x.Id == id, cancellationToken);
        }

    }// end of TaskItemRepository class

}
