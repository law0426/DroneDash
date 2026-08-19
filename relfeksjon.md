

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


Catching the delayMs value error in the iterator leaves weird behavior
Probably more appropriate to make it throw an error.

At least it's not iterating with the error. 
I would like to reduce the amount of error messages that occur from this, but I'm not sure that's the point.
I was told to: "Legg try/catch rundt orkestreringen for enkel feilrapportering."
But since I can't tell what I'm actually trying to achieve with that, I think I just have to throw an error on myself.
Maybe they meant put it around the whole function call? That sure cleanes up the messages, but now it's just harder to track down the issue lol.


Comparing the methods, very little actually changed. Perhaps I'm doing it wrong.
It looks like I don't really save that much work, although that does depend partly on the amount of threads I'm running.
the functions that get added to the threads and tasks are functionally the same.
Sleep gets replaced with delay - with added await.
Thread gets replaced with Task.
So mostly I just get the await Task.WhenAll(); to save some lines.
Maybe if I used iterators more and cycled through more drones, the value would become more apparent.

But the biggest value that I'm aware of wasn't even something that I got to experience: it's the thread pool management
that the tasks are supposed to handle for you.
I wonder if that means the project could handle drones beyond the thread count, if it swaps tasks during delays.
Although if it's supposed to accurately race the drones, that could get funky due to
things not actually happening simultaneously but in rapid sequence.




