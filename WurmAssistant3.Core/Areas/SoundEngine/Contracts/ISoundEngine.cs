﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AldursLab.WurmAssistant3.Core.Areas.SoundEngine.Contracts
{
    public interface ISoundEngine
    {
        IPlayingSoundHandle PlayOneShot(Guid soundId);

        IPlayingSoundHandle PlayOneShot(ISoundResource soundResource);

        ChooseSoundResult ChooseSound();
        void ShowSoundManager();
        void StopAllSounds();
        float GlobalVolume { get; set; }
        ISoundResource GetSoundById(Guid soundId);
    }

    public class ChooseSoundResult
    {
        public ActionResult ActionResult { get; private set; }
        public ISoundResource SoundResource { get; private set; }

        public ChooseSoundResult(ActionResult actionResult, ISoundResource soundResource)
        {
            ActionResult = actionResult;
            SoundResource = soundResource;
        }
    }

    public enum ActionResult
    {
        Cancel = 0,
        Ok
    }
}
