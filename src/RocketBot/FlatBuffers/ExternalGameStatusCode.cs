﻿namespace RocketBot.FlatBuffers
{
    public enum ExternalGameStatusCode
    {
        Success,
        BufferOverfilled,
        MessageLargerThanMax,
        InvalidNumPlayers,
        InvalidBotSkill,
        InvalidHumanIndex,
        InvalidName,
        InvalidTeam,
        InvalidTeamColorID,
        InvalidCustomColorID,
        InvalidGameValues,
        InvalidThrottle,
        InvalidSteer,
        InvalidPitch,
        InvalidYaw,
        InvalidRoll,
        InvalidPlayerIndex,
        InvalidQuickChatPreset,
        InvalidRenderType,
        QuickChatRateExceeded,
        NotInitialized
    }
}
