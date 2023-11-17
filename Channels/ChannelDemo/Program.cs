// See https://aka.ms/new-console-template for more information
using System.Threading.Channels;

var unbounded = Channel.CreateUnbounded<int>();
