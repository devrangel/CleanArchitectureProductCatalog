using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<CategoryDTO>> GetAsync()
        {
            var categoriesEntity = await _repository.GetAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }
        
        public async Task<CategoryDTO> GetByIdAsync(int? id)
        {
            var categoryEntity = await _repository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task AddAsync(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _repository.CreateAsync(categoryEntity);
        }
        
        public async Task UpdateAsync(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _repository.UpdateAsync(categoryEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var categoryEntity = _repository.GetByIdAsync(id).Result;
            await _repository.RemoveAsync(categoryEntity);
        }
    }
}
