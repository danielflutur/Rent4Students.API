using Microsoft.AspNetCore.Http;
using Rent4Students.Application.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent4Students.Application.Services.Interfaces
{
    public interface IFinancialHelpDocumentService
    {
        Task<ResponseStudentDTO> UploadTemplate(IFormFile rentTemplate);
        Task<ResponseStudentDTO> GetById(Guid id);
        Task<List<ResponseStudentDTO>> GetAll();
        Task<ResponseStudentDTO> UpdateDocument(Guid id, UpdateStudentDTO studentDTO);
        Task Delete(Guid id);
    }
}
