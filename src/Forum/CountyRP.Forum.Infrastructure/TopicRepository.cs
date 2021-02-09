﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.Infrastructure.DbContexts;

namespace CountyRP.Forum.Infrastructure
{
    public class TopicRepository : ITopicRepository
    {
        private readonly TopicContext _topicContext;

        public TopicRepository(TopicContext topicContext)
        {
            _topicContext = topicContext;
        }

        public async Task<IEnumerable<Topic>> GetByForumId(int id)
        {
            var topics = await _topicContext.Topics
                .Where(t => t.ForumId == id)
                .ToListAsync();

            return topics;
        }

        public async Task<Topic> CreateTopic(Topic topic)
        {
            _topicContext.Topics.Add(topic);

            await _topicContext.SaveChangesAsync();

            return topic;
        }

        public async Task<Topic> Edit(int id, Topic topic)
        {
            var existingTopic = _topicContext.Topics.FirstOrDefault(t => t.Id == id);
            existingTopic.Caption = topic.Caption;

            await _topicContext.SaveChangesAsync();

            return existingTopic;
        }

        public async Task Delete(int id)
        {
            var topic = _topicContext.Topics.FirstOrDefault(t => t.Id == id);

            _topicContext.Topics.Remove(topic);

            await _topicContext.SaveChangesAsync();
        }
    }
}
