

Without a join function or await (WhenAll) command, the main thread just barrels on without waiting

But I am a little curious as to what is considered a main thread. And if there's an override to it
if my CPU has 7 cores, does that mean 7 threads?

if so, if I use 7 threads, does that mean there is no main thread?
Is that one used up for the other drone racers?
Or is that one always "reserved" and can't be allocated like other threads

If the prior - does that mean the main thread will continue once the designated drone/thread finished its race?

I dunno.

Well, apparently I won't be working with threads anymore, but it's good to know how it accepts certain functions


Join and await imply that a command is given to the threads, even though what actually seems to happen
is that the main thread is told to take a chill pill until the other threads have finished.

The async tasks don't like being called without await. So I'm not entirely sure what it does, but it seems like there might be more to it.

