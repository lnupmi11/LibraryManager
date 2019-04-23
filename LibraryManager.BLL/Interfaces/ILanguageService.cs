using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DTO.Models;

namespace LibraryManager.BLL.Interfaces
{
    public interface ILanguageService
    {
        
        void Create(LanguageDTO languageDTO);
        IEnumerable<LanguageDTO> GetAll();
        void Update(LanguageDTO languageDTO);
        void Delete(int id);
        LanguageDTO Find(int id);
    }
}
