using WBAuth.DAL.IRepository;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace WBAuth.BLL.Manager
{
   public class JournalisationManager : IJournalisationManager
    {
        private readonly IJournalisationRepository _IJournalisationRepository;
        private readonly IMapper _mapper;

        public JournalisationManager(IJournalisationRepository IJournalisationRepository, IMapper mapper)
        {
            _IJournalisationRepository = IJournalisationRepository;
            _mapper = mapper;
        }


        public async Task<int> Ajouter(Journalisation oJournalisation)
        {
            if (oJournalisation == null) throw new ArgumentNullException(nameof(oJournalisation));
            var entity = _mapper.Map<DAL.Models.Journalisation> (oJournalisation);
            var id = await _IJournalisationRepository.Ajouter(entity);
            return id;
        }


        public async Task<IEnumerable<Journalisation>> ChargerAll()
        {
            var Journalisations = await _IJournalisationRepository.ChargerAll();
            var model = _mapper.Map<List<Journalisation>>(Journalisations);
            return model;
        }


        public async Task<Journalisation> Recherche(int Id)
        {
            var oJournalisation = await _IJournalisationRepository.Recherche(Id);
            var model = _mapper.Map<Journalisation>(oJournalisation);
            return model;
        }


        public async Task<int> Modifier(Journalisation oJournalisation)
        {
            if (oJournalisation == null) throw new ArgumentNullException(nameof(oJournalisation));
            var entity = _mapper.Map<DAL.Models.Journalisation>(oJournalisation);
            var id = await _IJournalisationRepository.Modifier(entity);
            return id;
        }


        public async Task<bool> Suprimer(int Id)   {   return await _IJournalisationRepository.Suprimer(Id);     }



    }
}
