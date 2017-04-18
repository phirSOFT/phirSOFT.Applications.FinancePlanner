# Behaviour of the progress Manager

The progressmanager is manages a collection of progresses. This are usually time consuming background tasks. Each registred progress should report its progress through the ```IProgress<ProgressReport>``` interface. Depending on the state of the progress the folling items shoud be submitted:

|State        |Progress|Title|Description  |
|-------------|:------:|:---:|-------------|
|Running      | x      | x   | __optional__|
|Paused       | x      | x   | __optional__|
|Intermediate |        | x   | __optional__|
|Faultet      |        | x   | __optional__|
|Finished     |        | x   | __optional__|

To determinate the aggregated state following Algorithm is used.
``` C#
// Let data store all running progresses
IEnumerable<ProgressReport> data;

ProgressStates state;
double progress;

if(_progresses.Any(p => p.State == ProgressStates.Running))
{
    state = ProgressStates.Running;
    progress = _progresses.Where(p => p.State == ProgressStates.Running).Average(p => p.Progress);

    return;
}

if (_progresses.Any(p => p.State == ProgressStates.Paused))
{
    state = ProgressStates.Paused;
    progress = _progresses.Where(p => p.State == ProgressStates.Paused).Average(p => p.Progress);

    return;
}

if (_progresses.Any(p => p.State == ProgressStates.Intermediate))
{
    state = ProgressStates.Intermediate;              

    return;
}

if (_progresses.Any(p => p.State == ProgressStates.Faultet))
{
    state = ProgressStates.Faultet;

    return;
}

if (_progresses.Any(p => p.State == ProgressStates.Finished))
{
    state = ProgressStates.Finished;

    return;
}

```
