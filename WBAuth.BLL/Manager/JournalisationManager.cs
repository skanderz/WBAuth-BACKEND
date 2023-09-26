﻿using AutoMapper;
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



        public async Task<IEnumerable<Journalisation>> ChargerListe(int IdUtilisateur)
        {
            var Journalisations = await _IJournalisationRepository.ChargerListe(IdUtilisateur);
            if (Journalisations == null) throw new ArgumentNullException(nameof(Journalisations));
            var model = _mapper.Map<List<Journalisation>>(Journalisations);
            return model;
        }


        public async Task<Journalisation> Recherche(int Id)
        {
            var oJournalisation = await _IJournalisationRepository.Recherche(rech);
            if (oJournalisation == null) throw new ArgumentNullException(nameof(oJournalisation));
            var model = _mapper.Map<Journalisation>(oJournalisation);
            return model;
        }



        public async Task<bool> Clear(int IdUtilisateur) { return await _IJournalisationRepository.Clear(IdUtilisateur); }


        public async Task<int> EnregistrementJournalisation(int IdUtilisateur)
        {
            // Saisir Await // 
            throw new NotImplementedException();
        }






    }
}
