﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.Infrastructure.DbContexts;

namespace CountyRP.Forum.Infrastructure
{
    public class PostRepository : IPostRepository
    {
        private PostContext _postContext;
        public PostRepository(PostContext postContext)
        {
            _postContext = postContext;
        }

        public async Task<Post> Create(Post post)
        {
            _postContext.Posts.Add(post);

            await _postContext.SaveChangesAsync();

            return post;
        }

        public async Task Delete(int postId)
        {
            var post = _postContext.Posts.FirstOrDefault(p => p.Id == postId);

            _postContext.Posts.Remove(post);

            await _postContext.SaveChangesAsync();
        }

        public async Task<Post> Edit(int id, Post post)
        {
            var existingPost = _postContext.Posts.FirstOrDefault(p => p.Id == id);
            existingPost.Text = post.Text;
            existingPost.LastEditorid = post.LastEditorid;
            existingPost.EditionDateTime = DateTime.Now;

            await _postContext.SaveChangesAsync();

            return existingPost;
        }

        public async Task<IEnumerable<Post>> GetPosts(int topicId)
        {
            return await _postContext.Posts
                .Where(p => p.TopicId == topicId)
                .ToListAsync();
        }

        public async Task<Post> GetLastPostInTopic(int topicId)
        {
            return await _postContext.Posts
                .OrderByDescending(p => p.CreationDateTime)
                .FirstOrDefaultAsync();
        }
    }
}
