using Cleverbit.CodingTask.Application.abstractions;
using Cleverbit.CodingTask.Core.Interfaces;
using Cleverbit.CodingTask.Core.Interfaces.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;


namespace Cleverbit.CodingTask.Application.Implementaions
{
    public class Play : IPlay
    {

        private readonly IPlayRepository _playRepository;
        private readonly ILogger<Play> _logger;
        private readonly IUnitOfWork _uow;


        public Play(IPlayRepository playRepository, ILogger<Play> logger, IUnitOfWork uow)
        {
            _playRepository = playRepository;
            _logger = logger;
            _uow = uow;
        }

        public async Task PlayNow(int user, Guid match)
        {

            _logger.LogInformation(nameof(PlayNow), "Initialize");

            try
            {

               if( await _playRepository.NoPlayAgain(user, match))
                    throw new Exception("Already played this match");

                await _uow.Commit();
            }
            catch (Exception exception)
            {
                  _logger.LogError($"Error PlayNow {exception.Message}");
            }

            _logger.LogInformation(nameof(PlayNow), "End");

        }
    }
}
