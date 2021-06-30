using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ProductDTO>> GetAsync()
        {
            var productsQuery = new GetProductsQuery();
            
            if(productsQuery == null)
            {
                throw new Exception("Entity could not be loaded");
            }

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }
        
        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productQuery = new GetProductByIdQuery(id.Value);

            if (productQuery == null)
            {
                throw new Exception("Entity could not be loaded");
            }

            var result = await _mediator.Send(productQuery);

            return _mapper.Map<ProductDTO>(result);
        }
        
        //public async Task<ProductDTO> GetByCategoryIdAsync(int? id)
        //{
        //    var productQuery = new GetProductByIdQuery(id.Value);

        //    if (productQuery == null)
        //    {
        //        throw new Exception("Entity could not be loaded");
        //    }

        //    var result = await _mediator.Send(productQuery);

        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task AddAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(product);
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(product);
        }

        public async Task RemoveAsync(int? id)
        {
            var product = new ProductRemoveCommand(id.Value);

            if (product == null)
            {
                throw new Exception("Entity could not be loaded");
            }

            await _mediator.Send(product);
        }
    }
}
