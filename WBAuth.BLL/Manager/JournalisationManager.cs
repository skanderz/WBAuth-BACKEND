using AutoMapper;
using System.Collections.Generic;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAL.IRepository;



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


        public async Task<IEnumerable<Journalisation>> ChargerListe(string GuidUtilisateur)
        {
            var Journalisations = await _IJournalisationRepository.ChargerListe(GuidUtilisateur);
            if (Journalisations == null) throw new ArgumentNullException(nameof(Journalisations));
            var model = _mapper.Map<List<Journalisation>>(Journalisations);
            return model;
        }


        public async Task<Journalisation> RechercheById(int Id)
        {
            var oJournalisation = await _IJournalisationRepository.RechercheById(Id);
            if (oJournalisation == null) throw new ArgumentNullException(nameof(oJournalisation));
            var model = _mapper.Map<Journalisation>(oJournalisation);
            return model;
        }


        public async Task<IEnumerable<Journalisation>> Recherche(string rech)
        {
            var Journalisations = await _IJournalisationRepository.Recherche(rech);
            if (Journalisations == null) throw new ArgumentNullException(nameof(Journalisations));
            var models = _mapper.Map<List<Journalisation>>(Journalisations);
            return models;
        }


        public async Task<int> EnregistrementJournalisation(Journalisation oJournalisation)
        {
            if (oJournalisation == null) throw new ArgumentNullException(nameof(oJournalisation));
            var entity = _mapper.Map<DAL.Models.Journalisation>(oJournalisation);
            var id = await _IJournalisationRepository.EnregistrementJournalisation(entity);
            return id;
        }

        public async Task<bool> Clear(string GuidUtilisateur) { 
            return await _IJournalisationRepository.Clear(GuidUtilisateur); 
        }






    }
}
