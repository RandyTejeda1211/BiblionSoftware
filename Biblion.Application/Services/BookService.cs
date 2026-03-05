using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblion.Application.Interfaces;
using Biblion.Domain.entities;
using Biblion.Domain.Interfaces;

namespace Biblion.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task AddAsync(Book book)
        {
            await _bookRepository.AddAsync(book);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book?> GetById(Guid id)
        {
            return await _bookRepository.GetByIdAsync(id);      
        }

        public async Task UpdateAsync(Book book)
        {
            await _bookRepository.UpdateAsync(book);
        }
    }
}
